import { WordsService } from '@/scripts/wordsService'

describe('Word Service', () => {
  test('Get a word', () => {
    const word = WordsService.getRandomWord()
    expect(word).not.toBeNull()
    expect(word).toHaveLength(5)
    expect(word).not.toHaveLength(4)
  })

  test('Words are private', () => {
    expect((WordsService as any).words).toBeUndefined()
  })

  test('Valid words match specific entry', () => {
    expect(WordsService.validWords("acorn").length).toBe(1);
    expect(WordsService.validWords("bi???").length).toBe(9);
    expect(WordsService.validWords("a???n").length).not.toBe(5); //Actual value is 4
  })
})
