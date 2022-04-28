<template>
  <v-card>
    <v-menu offset-y>
      <template v-slot:activator="{ on, attrs }">
        <v-btn dark v-bind="attrs" v-on="on">
          <v-icon> mdi-hamburger </v-icon>
        </v-btn>
      </template>
      <v-tooltip left>
        <template #activator="{ on, attrs }">
          <v-btn icon to="/about-us" v-bind="attrs" v-on="on">
            <v-icon> mdi-account </v-icon>
          </v-btn>
        </template>
        <span>About Us</span>
      </v-tooltip>
      <settings-dialog />
    </v-menu>
  </v-card>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator'
import SettingsDialog from '@/components/settings-dialog.vue'

@Component({ components: { SettingsDialog } })
export default class BurgerMenu extends Vue {}
</script>
