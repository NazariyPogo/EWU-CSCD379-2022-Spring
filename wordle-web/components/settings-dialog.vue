<template>
  <div>
    <v-tooltip left>
      <template #activator="{ on, attrs }">
        <v-btn icon v-bind="attrs" @click="toggleDialog" v-on="on">
          <v-icon> mdi-cog </v-icon>
        </v-btn>
      </template>
      <span>Settings</span>
    </v-tooltip>

    <v-dialog v-model="dialog" width="450">
      <v-card>
        <v-container>
          <v-card-title> Settings </v-card-title>

          <v-card-text>
            <v-menu offset-y>
              <template #activator="{ on, attrs }">
                <v-btn color="primary" dark v-bind="attrs" v-on="on">
                  Pick Theme
                </v-btn>
              </template>
              <v-list>
                <v-list-item-group>
                  <v-list-item @click="turnOnTheLights">
                    <v-list-item-title> Light Mode </v-list-item-title>
                  </v-list-item>
                  <v-list-item @click="turnOffTheLights">
                    <v-list-item-title> Dark Mode </v-list-item-title>
                  </v-list-item>
                </v-list-item-group>
              </v-list>
            </v-menu>

            <v-menu offset-y>
              <template #activator="{ on, attrs }">
                <v-btn color="primary" dark v-bind="attrs" v-on="on">
                  Pick A Color
                </v-btn>
              </template>
              <v-list>
                <v-list-item-group>
                  <v-list-item @click="purpleTheme">
                    <v-list-item-title> Purple </v-list-item-title>
                  </v-list-item>
                  <v-list-item @click="autumnTheme">
                    <v-list-item-title> Autumn </v-list-item-title>
                  </v-list-item>
                  <v-list-item @click="oldTheme">
                    <v-list-item-title> Old </v-list-item-title>
                  </v-list-item>
                </v-list-item-group>
              </v-list>
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

  autumnTheme() {
    const autumnTheme = {
      primary: '#03a9f4',
      secondary: '#009688',
      accent: '#00bcd4',
      error: '#e91e63',
      warning: '#ff9800',
      info: '#9c27b0',
      success: '#8bc34a',
    }

    this.$vuetify.theme.themes.dark = autumnTheme
    this.$vuetify.theme.themes.light = autumnTheme
  }

  oldTheme() {
    const oldThemeDark = {
      primary: '#9e9e9e',
      secondary: '#757575',
      accent: '#e0e0e0',
      error: '#212121',
      warning: '#757575',
      info: '#eeeeee',
      success: '#e0e0e0',
    }

    const oldThemeLight = {
      primary: '#9e9e9e',
      secondary: '#757575',
      accent: '#e0e0e0',
      error: '#616161',
      warning: '#bdbdbd',
      info: '#eeeeee',
      success: '#fafafa',
    }
    if (this.$vuetify.theme.dark === true) {
      this.$vuetify.theme.themes.dark = oldThemeDark
    } else {
      this.$vuetify.theme.themes.light = oldThemeLight
    }
  }
}
</script>
