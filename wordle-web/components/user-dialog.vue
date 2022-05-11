<template>
  <div class>
    <v-container @click="toggleDialog">
      {{ newName }}
    </v-container>

    <v-dialog v-model="dialog" width="450">
      <v-card>
        <v-container>
          <v-card-title>User</v-card-title>

          <v-card-text>
            <v-text-field v-model="name" label="User" />
            <v-btn color="primary" dark @click="changeName"> Save </v-btn>
          </v-card-text>
        </v-container>
      </v-card>
    </v-dialog>
  </div>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator'

@Component({})
export default class SettingsDialog extends Vue {
  dialog = false
  name = 'Guest'
  newName = localStorage.getItem('newName')

  toggleDialog() {
    this.dialog = !this.dialog
  }

  changeName() {
    localStorage.setItem('newName', this.name)
    this.newName = localStorage.getItem('newName')
  }
}
</script>
