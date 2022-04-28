<template>
  <v-card>
    <v-menu offset-y open-on-hover>
      <template #activator="{ on, attrs }">
        <v-btn icon v-bind="attrs" v-on="on">
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
    </v-menu>
  </v-card>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator'

@Component({ components: {} })
export default class BurgerMenu extends Vue {}
</script>
