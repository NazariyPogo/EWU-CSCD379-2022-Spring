<template>
  <v-app>
    <v-app-bar fixed app>
      <router-link to="/" class="text-h4 font-weight-black no-decoration">
        Wordle
        <v-icon> mdi-penguin </v-icon>
      </router-link>
      <v-spacer />
      <settings-dialog />
      <burger-menu />
    </v-app-bar>
    <v-main>
      <v-container>
        <Nuxt />
      </v-container>
    </v-main>
    <v-footer app>
      <span>&copy; {{ new Date().getFullYear() }}</span>
    </v-footer>
  </v-app>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator'
import SettingsDialog from '@/components/settings-dialog.vue'
import BurgerMenu from '@/components/burger-menu.vue'

@Component({ components: { BurgerMenu, SettingsDialog } })
export default class DefaultLayout extends Vue {}
</script>

<style>
.no-decoration {
  text-decoration: none;
}
</style>
