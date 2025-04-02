<script setup lang="ts">
import axios from 'axios'
import { computed, ref } from 'vue'

const model = defineModel<Set<string>>({ default: [] })
const genres = ref<string[]>([])

const onChange = (event: Event) => {
  const genre = (event.target as HTMLSelectElement).value
  if (genre === '') {
    model.value = new Set<string>()
    return
  }

  model.value = new Set<string>([genre])
}

const currentValue = computed(() => {
  return model.value.size > 0 ? Array.from(model.value)[0] : ''
})

axios
  .request({
    method: 'get',
    url: 'http://localhost:5195/anime/genres',
  })
  .then((response) => {
    genres.value = response.data
  })
  .catch((error) => {
    console.error('Error fetching genres:', error)
  })
</script>

<template>
  <div class="form-select">
    <i class="icon-search"></i>
    <select id="genres" name="genres" v-bind:value="currentValue" @change="onChange">
      <option value="">Genres</option>
      <option v-for="(genre, index) in genres" :key="index" :value="genre">
        {{ genre }}
      </option>
    </select>
  </div>
</template>

<style scoped>
.form-select {
  vertical-align: bottom;

  select {
    line-height: 26px;
    padding-top: 0;
    padding-bottom: 0;
    font-size: inherit !important;
  }
}
</style>
