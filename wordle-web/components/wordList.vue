<template>
  <div>
    <v-btn @click="toggleDialog()" :disabled="wordleGame.gameOver">
      {{ listLength() }}
    </v-btn>

    <v-dialog v-model="dialog" width="200">
      <v-card>
        <v-container>
          <v-card-title> Possible Words </v-card-title>

          <v-card-text>
            <v-virtual-scroll
              :items="wordsService.validWords(this.wordleGame.currentWord.text)"
              v-if="dialog"
              height="300"
              width="150"
              item-height="64"
            >
              <template v-slot:default="{ item }">
                <v-list-item :key="item">
                  <v-list-item-action>
                    <v-btn depressed color="primary" @click="setWord(item)">
                      {{ item }}
                    </v-btn>
                  </v-list-item-action>
                </v-list-item>

                <v-divider></v-divider>
              </template>
            </v-virtual-scroll>
          </v-card-text>
        </v-container>
      </v-card>
    </v-dialog>
  </div>
</template>

<script lang="ts">
import { Component, Vue, Prop } from 'vue-property-decorator'
import { WordleGame } from '~/scripts/wordleGame'
import { WordsService } from '~/scripts/wordsService'

@Component
export default class WordList extends Vue {
  @Prop({ required: true })
  wordleGame!: WordleGame

  wordsService = WordsService
  dialog = false

  toggleDialog() {
    this.dialog = !this.dialog
  }

  listLength() {
    return this.wordsService.validWords(this.wordleGame.currentWord.text).length
  }

  setWord(item: string) {
    for(let i = 0; i < 5; i++) {
      this.wordleGame.currentWord.removeLetter()
    }
    for(let i = 0; i < 5; i++) {
      this.wordleGame.currentWord.addLetter(item[i])
    }
  }
}
</script>
