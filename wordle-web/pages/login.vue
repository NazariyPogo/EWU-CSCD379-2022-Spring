<template>
  <v-container fluid fill-height>
    <v-container>
      <v-form>
        <v-card>
          <v-card-title>Login</v-card-title>
          <v-row>
            <v-col cols="12" md="4">
              <v-text-field v-model="email" label="Email" required>
              </v-text-field>
            </v-col>

            <v-col cols="12" md="4">
              <v-text-field
                v-model="password"
                label="Password"
                required
              ></v-text-field>
            </v-col>
          </v-row>
          <v-card-actions>
            <v-btn @click="signIn()"> Login </v-btn>
          </v-card-actions>
        </v-card>
      </v-form>
    </v-container>
  </v-container>
</template>

<script lang="ts">
import { Vue } from 'vue-property-decorator'
import { JWT } from '~/scripts/jwt'

export default class Login extends Vue {
  email: string = ''
  password: string = ''

  signIn() {
    this.$axios
      .post('Token/GetToken', {
        username: this.email,
        password: this.password,
      })
      .then((result) => {
        JWT.setToken(result.data.token, this.$axios)
        this.$axios.defaults.headers.common.Authorization =
          'Bearer ' + result.data.token
      })
  }
}
</script>
