<template>
  <v-container fluid fill-height>
    <v-container v-if="!isLoaded">
      <v-row justify="center">
        <v-card loading>
          <v-card-title class="justify-center">
            You're being exploited for ad revenue, please standby...
          </v-card-title>
          <PrerollAd />
        </v-card>
      </v-row>
    </v-container>

    <v-container v-if="isLoaded">
      <p>{{ this.wordleGame.word }}</p>
      <v-row justify="end">
        <v-btn>
          <v-container @click="toggleDialog">
            {{ newName }}
          </v-container>

          <v-dialog v-model="dialog" width="450" persistent>
            <v-card>
              <v-container>
                <v-card-title>User</v-card-title>

                <v-card-text>
                  <v-text-field v-model="name" label="User" />
                  <v-btn color="primary" dark @click="changeName"> Save </v-btn>
                </v-card-text>
              </v-container>
            </v-card>
          </v-dialog>
        </v-btn>
      </v-row>
      <v-row justify="center">
        <v-col cols="1" class="mt-0 mb-0 pt-0 pb-0">
          <v-tooltip bottom>
            <template #activator="{ on, attrs }">
              <v-container>
                <v-row justify="center">
                  <v-btn
                    color="primary"
                    x-small
                    nuxt
                    to="/"
                    fab
                    v-bind="attrs"
                    v-on="on"
                  >
                    <v-icon>mdi-home</v-icon>
                  </v-btn>
                </v-row>
              </v-container>
            </template>
            <span> Go Home </span>
          </v-tooltip>
        </v-col>
      </v-row>

      <v-row justify="center" class="mt-0 pt-2">
        <v-col class="mt-2 mb-0 pt-0 pb-0">
          <v-card flat color="transparent" class="mt-0 mb-0 pt-0 pb-0">
            <v-card-text
              class="text-h3 font-weight-black text-center ma-0 pa-0"
            >
              !Wordle
            </v-card-text>
          </v-card>
        </v-col>
      </v-row>

      <v-row justify="center" class="mt-10">
        <v-alert v-if="wordleGame.gameOver" width="80%" :type="gameResult.type">
          {{ gameResult.text }}
          <v-btn class="ml-2" @click="resetGame" color="primary"> Play Again? </v-btn>
          <v-btn @click="checkForName()" color="primary" :disabled="saved">
            Save Score?
          </v-btn>
          <v-btn @click="areYouSure()" color="primary" :disabled="unsure">
            Are you sure?
          </v-btn>
        </v-alert>
      </v-row>

      <v-row justify="center">
        <game-board :wordleGame="wordleGame" />
      </v-row>
      <v-row justify="center">
        <keyboard :wordleGame="wordleGame" />
      </v-row>
    </v-container>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'
import { WordsService } from '~/scripts/wordsService'
import { GameState, WordleGame } from '~/scripts/wordleGame'
import KeyBoard from '@/components/keyboard.vue'
import GameBoard from '@/components/game-board.vue'
import { Word } from '~/scripts/word'

@Component({ components: { KeyBoard, GameBoard } })
export default class Game extends Vue {
  word: string = WordsService.getRandomWord()
  wordleGame = new WordleGame(this.word)

  dialog = false
  name = 'Guest'
  newName = localStorage.getItem('newName')
  saved = false
  unsure = true

  isLoaded: boolean = false

  mounted() {
    setTimeout(() => {
      this.isLoaded = true
    }, 5000)
  }

  resetGame() {
    this.word = WordsService.getRandomWord()
    this.wordleGame = new WordleGame(this.word)
    this.saved = false
    this.unsure = true
  }

  get gameResult() {
    if (this.wordleGame.state === GameState.Won) {
      return { type: 'success', text: 'You won! :^)' }
    }
    if (this.wordleGame.state === GameState.Lost) {
      return {
        type: 'error',
        text: `You lost... :^( The word was ${this.word}`,
      }
    }
    return { type: '', text: '' }
  }

  getLetter(row: number, index: number) {
    const word: Word = this.wordleGame.words[row - 1]
    if (word !== undefined) {
      return word.letters[index - 1]?.char ?? ''
    }
    return ''
  }

  toggleDialog() {
    this.dialog = !this.dialog
  }

  changeName() {
    localStorage.setItem('newName', this.name)
    this.newName = localStorage.getItem('newName')
    this.toggleDialog()
  }

  checkForName() {
    this.saved = !this.saved
    if (this.newName === 'Guest') {
      this.toggleDialog()
      this.toggleUnsure()
    } else {
      this.savePlayerStats()
    }
  }

  areYouSure(){
    this.savePlayerStats()
    this.toggleUnsure()
  }

  savePlayerStats() {
    this.$axios
      .post('/api/Player', {
        Name: this.newName,
        Score: this.wordleGame.words.length,
      })
      .then(function (response) {
        console.log(response)
      })
      .catch(function (error) {
        console.log(error)
      })
  }

  toggleUnsure(){
    this.unsure = !this.unsure
  }
}
</script>
