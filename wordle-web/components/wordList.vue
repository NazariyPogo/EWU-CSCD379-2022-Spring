<template>
  <div>
    <v-btn @click="toggleDialog">
      {{ possibleWords }}
    </v-btn>

    <v-dialog v-model="dialog" width="450">
      <v-card>
        <v-container>
          <v-card-title> All Possible Words </v-card-title>
          <v-card-text>
            <v-card elevation="16" max-width="400" class="mx-auto">
            </v-card>
          </v-card-text>
        </v-container>
      </v-card>
    </v-dialog>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'
import { WordsService } from '~/scripts/wordsService'

@Component
export default class WordList extends Vue {
  dialog = false
  possibleWords = 630
  possibleWordList = []
  wordList = WordsService.validWords

  toggleDialog() {
    this.dialog = !this.dialog
  }
  
}
</script>
