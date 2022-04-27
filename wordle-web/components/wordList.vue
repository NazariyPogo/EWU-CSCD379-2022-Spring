<template>

</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'
import { WordsService } from '~/scripts/wordsService'

@Component
export default class WordList extends Vue {
	possibleWords = [];
	wordList = WordsService.validWords;
}

</script>