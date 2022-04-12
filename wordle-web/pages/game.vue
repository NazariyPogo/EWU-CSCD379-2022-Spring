<template>
  <v-row>
    <v-col class="text-center">
      <v-card elevation="1" shaped>
        <v-card-title>Wordless</v-card-title>
        <v-card-text>
          <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
            Suspendisse dolor ex, lobortis id dapibus feugiat, luctus 
            at ipsum. Nullam lacus tortor, malesuada eget urna id, 
            posuere vulputate mi. Proin ut aliquet risus. Cras 
            fermentum in mauris ac ornare. Etiam aliquam lacus quam, 
            eu venenatis risus rutrum ac. Nulla facilisi. Nulla 
            facilisi. Mauris ac ullamcorper ex.
          </p>
        </v-card-text>
        <v-card-actions>
          <v-btn color="primary" nuxt to="/">Back to index</v-btn>
        </v-card-actions>
      </v-card>
    </v-col>
  </v-row>
</template>

<script>
export default {
  name: 'GamePage',
}
</script>
