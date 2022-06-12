<template>
  <v-container fluid fill-height justify-center>
    <v-card width="65%">
      <v-card-title class="display-3 justify-center"> Word List </v-card-title>
      <v-card-text>
        <v-row>
          <v-text-field
            v-model="search"
            label="Search Words"
            @input="applyFilter()"
          >
          </v-text-field>
        </v-row>
        <v-row>
          <v-col :cols="9">
            <v-text-field v-model="newWord" label="New Word"> </v-text-field>
          </v-col>
          <v-col>
            <v-btn @click="addWord"> Add Word </v-btn>
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
              <td style="text-align: center">
                <v-checkbox
                  v-model="word.common"
                  @click="toggleCommonWord(word.value, word.common)"
                ></v-checkbox>
              </td>
              <td style="text-align: center">
                <v-btn color="primary" @click="deleteWord(word.value)">
                  Delete
                </v-btn>
              </td>
            </tr>
          </tbody>
        </v-simple-table>
      </v-card-text>
      <template>
        <div>
          <v-pagination
            v-model="page"
            circle
            :length="numberOfPages"
            @input="updateList()"
          >
          </v-pagination>
        </div>
      </template>
    </v-card>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'

@Component({})
export default class wordlist extends Vue {
  words: any = []
  listSize = 1
  wordPerPage = 50
  numberOfPages = 10
  newWord = ''
  page = 1
  search = ''

  mounted() {
    this.updateList()
  }

  addWord() {
    this.$axios
      .post('/Word/AddWord', {
        value: this.newWord,
        common: false,
      })
      .then(this.updateList)
  }

  deleteWord(word: string) {
    this.$axios
      .post('/Word/RemoveWord', null, {
        params: { word },
      })
      .then(this.updateList)
  }

  toggleCommonWord(word: string, common: boolean) {
    this.$axios.post('/Word/ChangeFlag', {
      value: word,
      common,
    })
  }

  updateList() {
    if (this.search === '') {
      this.$axios
        .get('/Word/GetList', {
          params: {
            pageNum: this.page,
            pageSize: this.wordPerPage,
          },
        })
        .then((res) => (this.words = res.data))
        .then(this.getListSize)
    } else {
      this.$axios
        .get('/Word/GetFilteredList', {
          params: {
            pageNum: this.page,
            pageSize: this.wordPerPage,
            filter: this.search,
          },
        })
        .then((res) => (this.words = res.data))
        .then(this.getListSize)
    }
  }

  getListSize() {
    if (this.search === '') {
      this.$axios
        .get('/Word/GetListSize')
        .then((res) => (this.listSize = res.data))
        .then(this.setPageNumber)
    } else {
      this.$axios
        .get('/Word/GetFilteredListSize', {
          params: {
            filter: this.search,
          },
        })
        .then((res) => (this.listSize = res.data))
        .then(this.setPageNumber)
    }
  }

  setPageNumber() {
    this.numberOfPages = Math.ceil(this.listSize / this.wordPerPage)
  }

  applyFilter(){
    this.page = 1
    this.updateList()
  }
}
</script>
