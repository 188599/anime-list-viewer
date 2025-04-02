<script setup lang="ts">
import { AnimeFilter } from '@/models/anime-filter'
import { ref } from 'vue'
import { defineEmits } from 'vue'
import AnimeGenresFilter from './AnimeGenresFilter.vue'

const emit = defineEmits<{
  (e: 'filterChanged', filter: AnimeFilter): void
}>()

const params = AnimeFilter.fromParams()
const filter = ref<Omit<AnimeFilter, 'genres'>>(params)
const genres = ref<Set<string>>(new Set<string>(params.genres ?? []))

const scorePattern = ref(AnimeFilter.scorePattern.source)

const onSubmit = (event: Event) => {
  event.preventDefault()

  emit('filterChanged', { ...filter.value, genres: Array.from(genres.value) })
}

const clearFilters = () => {
  emit('filterChanged', new AnimeFilter())
}
</script>

<template>
  <div class="filters">
    <form>
      <span class="form-input">
        <i class="icon-search"></i>
        <input type="text" id="title" name="title" placeholder="Title" v-model="filter.title" />
      </span>

      <span class="form-input">
        <i class="icon-search"></i>
        <input type="number" id="year" name="year" placeholder="Year" v-model="filter.year" />
      </span>

      <span class="form-input">
        <i class="icon-search"></i>
        <input
          type="text"
          id="year"
          name="year"
          placeholder="Score (eg. 8.5 or 8.5-10)"
          v-mask="scorePattern"
          v-model="filter.score"
        />
      </span>

      <AnimeGenresFilter v-model="genres" />

      <button type="button" class="form-button button clear" @click="onSubmit">Apply Filters</button>

      <button type="button" class="form-button button clear" @click="clearFilters">
        Clear Filters
      </button>
    </form>
  </div>
</template>

<style scoped>
.filters {
  min-height: 26px;
  line-height: 26px;
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
  align-items: center;
  font-size: 80%;
}
</style>
