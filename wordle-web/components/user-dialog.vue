<template>
  <div class>
    <v-container @click="toggleDialog">
      User
    </v-container>

    <v-dialog v-model="dialog" width="450">
      <v-card>
        <v-container>
          <v-card-title>User</v-card-title>

          <v-card-text>
            <v-text-field v-model="name" label="User">
            </v-text-field>

            <v-menu offset-y>
              <template #activator="{ on, attrs }">
                <v-btn color="primary" dark v-bind="attrs" v-on="on">
                  Submit
                </v-btn>
              </template>
            </v-menu>
          </v-card-text>
        </v-container>
      </v-card>
    </v-dialog>
  </div>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator'
import { colors } from 'vuetify/lib'

@Component({})
export default class SettingsDialog extends Vue {
  dialog = false
  defaultDarkTheme = this.$vuetify.theme.themes.dark
  defaultLightTheme = this.$vuetify.theme.themes.light

  toggleDialog() {
    this.dialog = !this.dialog
  }

  turnOnTheLights() {
    this.$vuetify.theme.dark = false
  }

  turnOffTheLights() {
    this.$vuetify.theme.dark = true
  }

  purpleTheme() {
    const purpleTheme = {
      primary: colors.deepPurple,
      accent: colors.purple.accent3,
      secondary: colors.purple,
      info: '#03A9F4',
      warning: colors.pink.accent1,
      error: colors.pink.accent3,
      success: colors.deepPurple.lighten4,
    }
    this.$vuetify.theme.themes.dark = purpleTheme
    this.$vuetify.theme.themes.light = purpleTheme
  }

  orangeTheme() {
    const orangeTheme = {
      primary: colors.deepOrange,
      accent: colors.orange.accent3,
      secondary: colors.brown,
      info: '#FFA500',
      warning: colors.yellow.accent1,
      error: colors.amber.accent3,
      success: colors.pink.lighten4,
    }
    this.$vuetify.theme.themes.dark = orangeTheme
    this.$vuetify.theme.themes.light = orangeTheme
  }

  naturalTheme() {
    const naturalTheme = {
      primary: colors.lightGreen,
      accent: colors.brown.base,
      secondary: colors.blueGrey,
      info: '#FFA500',
      warning: colors.yellow.accent1,
      error: colors.red.accent3,
      success: colors.lightBlue.lighten4,
    }
    this.$vuetify.theme.themes.dark = naturalTheme
    this.$vuetify.theme.themes.light = naturalTheme
  }

  defaultTheme() {
    this.$vuetify.theme.themes.dark = this.defaultDarkTheme
    this.$vuetify.theme.themes.light = this.defaultLightTheme
  }
}
</script>
