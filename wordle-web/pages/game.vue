<template>
  <v-row>
    <v-col class="text-center">
      <img src="/v.png" alt="Vuetify.js" class="mb-5" />
      <blockquote class="blockquote">
        &#8220;Wordless&#8221;
        <footer>
          <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
            Suspendisse dolor ex, lobortis id dapibus feugiat, luctus 
            at ipsum. Nullam lacus tortor, malesuada eget urna id, 
            posuere vulputate mi. Proin ut aliquet risus. Cras 
            fermentum in mauris ac ornare. Etiam aliquam lacus quam, 
            eu venenatis risus rutrum ac. Nulla facilisi. Nulla 
            facilisi. Mauris ac ullamcorper ex.
          </p>
          <div>
            <v-btn color="primary" nuxt to="/">Back to index</v-btn>
          </div>
        </footer>
      </blockquote>
    </v-col>
  </v-row>
</template>

<script>
export default {
  name: 'InspirePage',
}
</script>
