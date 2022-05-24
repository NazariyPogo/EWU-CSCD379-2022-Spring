<template>
  <v-container>
    <v-row justify="center">
      <!-- Back Button -->
      <v-col cols="1">
        <v-btn
          fab
          v-bind="attrs"
          color="primary"
          v-on="on"
          @click="$router.go(-1)"
        >
          <v-icon>mdi-arrow-left</v-icon>
        </v-btn>
      </v-col>

      <!-- Game Info Card(s) -->
      <v-col cols="12">
        <v-card flat color="transparent">
          <v-card-title class="justify-center">
            <h1>!Wordle</h1>
          </v-card-title>
        </v-card>
      </v-col>

      <!-- Game Card -->
      <v-col cols="8">
        <v-card>
          <div class="d-flex align-center">
            <v-icon size="150" class="ma-6">mdi-file-word-box</v-icon>
            <v-card-text decoration>
              <b>Welcome to !Wordle</b><br />
              The Purpose of the game is to guess a randomized word within
              <b>6</b> attempts. With each guess submission, the gameboard will
              display your word with the letters changing colors.<br /><br />
              After each game, don't forget to set your name to be entered into the
              leaderboards! The people who are the best at guessing any word will be
              shown at the top!<br /><br />
              When playing the Word of the Day mode, a new word is chosen every day
              and will stay the same until the next day, so there's no way you can
              get addicted.<br />
              The Play mode, however, serves you a new word every game, play this mode
              <big>ONLY</big> if you are a <big>SERIOUS</big> Gamer!
            </v-card-text>
          </div>
        </v-card>
      </v-col>

      <!-- Color Introduction -->
      <v-col cols="12">
        <v-card flat color="transparent">
          <v-card-title class="justify-center">
            <h1>
              <font class="success rounded"
                ><span class="accent--text">CO</span></font
              >
              <font class="warning rounded"
                ><span class="accent--text">LO</span></font
              >
              <font class="error rounded"
                ><span class="accent--text">RS</span></font
              >
            </h1>
          </v-card-title>
        </v-card>
      </v-col>

      <v-col cols="8">
        <v-card>
          <div class="d-flex align-center">
            <v-avatar size="50" class="ma-6">
              <v-btn x-large class="success" />
            </v-avatar>
            <v-container fluid>
              <v-card flat>
                <v-card-text>
                  This color signifies that the letter exists and is in the
                  correct slot, nice one!
                </v-card-text>
              </v-card>
            </v-container>
          </div>
        </v-card>
      </v-col>

      <v-col cols="8">
        <v-card>
          <div class="d-flex align-center">
            <v-avatar size="50" class="ma-6">
              <v-btn x-large class="warning" />
            </v-avatar>
            <v-container fluid>
              <v-card flat>
                <v-card-text>
                  This color signifies that the letter exists, but is in the
                  wrong slot, try moving it to somewhere else!
                </v-card-text>
              </v-card>
            </v-container>
          </div>
        </v-card>
      </v-col>

      <v-col cols="8">
        <v-card>
          <div class="d-flex align-center">
            <v-avatar size="50" class="ma-6">
              <v-btn x-large class="error" />
            </v-avatar>
            <v-container fluid>
              <v-card flat>
                <v-card-text>
                  This color signifies that the letter does not exist in the
                  current word. hmm, try something different and clever, you can
                  do it!
                </v-card-text>
              </v-card>
            </v-container>
          </div>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import Vue from 'vue'
import Component from 'vue-class-component'

@Component
export default class InstructionPage extends Vue {}
</script>
