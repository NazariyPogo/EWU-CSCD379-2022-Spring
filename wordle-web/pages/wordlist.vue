<template>
  <v-container fluid fill-height justify-center>
    <v-card width="65%">
      <v-card-title class="display-3 justify-center">
        Word List
      </v-card-title>
      <v-card-text class="text-center">
        {{ title }}
      </v-card-text>
      <v-card-text>
        <v-row>
          <v-text-field label="Search Words">
          </v-text-field>
        </v-row>
        <v-row>
          <v-col :cols=9>
            <v-text-field label="New Word">
            </v-text-field>
          </v-col>
          <v-col>
            <v-btn 
            :justify="right"> 
              Add Word 
            </v-btn>
          </v-col>
        </v-row>
        <v-simple-table>
          <thead>
            <tr>
              <th>Word</th>
              <th style="text-align: center">Common Word</th>
              <th style="text-align: center">Delete?</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(word, index) in words" :key="index">
              <td>{{ word.value }}</td>
              <td style="text-align: center">{{ word.common }}</td>
              <td style="text-align: center">
                <v-btn color="primary">
                  Delete
                </v-btn>
              </td>
            </tr>
          </tbody>
        </v-simple-table>
      </v-card-text>
      <v-card-actions>
        <v-pagination
          v-model="currentPage"
          :length="numberOfPages"
          @input="nextPage" >
        </v-pagination>
      </v-card-actions>
    </v-card>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'

@Component({})
export default class wordlist extends Vue {
  words: any = []
  title: string = ''
  wordPerPage = 50
  numberOfPages = 20

  mounted() {
    this.$axios.get('/api/Words').then((response) => {
      this.words = response.data
    })
    this.numberOfPages = Math.round(this.words.length / this.numberOfPages)
  }
}
</script>
