<script setup lang="ts">
import { ref } from 'vue'
import axios from 'axios'
import AnimeCard from './components/AnimeCard.vue'
import type { Anime } from './models/anime'
import { AnimeFilter as Filter } from './models/anime-filter'
import AnimeFilter from './components/AnimeFilter.vue'

const data = ref<Anime[]>([])

axios
  .get<Anime[]>(`http://localhost:5195/anime/list`, {
    params: new URLSearchParams(window.location.search),
  })
  .then((response) => {
    data.value = response.data
  })
  .catch((error) => {
    console.error('Error fetching anime list:', error)
  })

const onFilterChanged = (filter: Filter) => {
  const params = Filter.toParams(filter).toString()

  if (params != '') {
    window.location.search = params
  } else {
    window.location.href = window.location.pathname
  }
}
</script>

<template>
  <header>
    <ul class="header-list">
      <li>
        <h1>Anime List Demo</h1>
      </li>
    </ul>
  </header>

  <div id="content">
    <AnimeFilter @filter-changed="onFilterChanged" />

    <main class="chart">
      <template v-for="(anime, index) in data" :key="index">
        <AnimeCard v-bind="anime" />
      </template>
    </main>
  </div>
</template>

<style scoped>
#content {
  padding-inline: 20px;
  padding-bottom: 20px;
}

.chart {
  margin: 0 0 0 1rem;
  clear: both;
}

@media print, screen and (max-width: 39.99875em) {
  .chart {
    margin-left: 0;
  }
}

header {
  font-size: 80%;

  ul {
    padding-inline-start: 25px;
  }

  h1 {
    font-weight: bold;
  }
}

.header-list {
  background: #1e1e1e;
  min-height: 50px;
  max-height: 50px;
  white-space: nowrap;
  display: flex;
  align-items: center;
  justify-content: center;
}

.header-list li {
  display: inline-block;
}
</style>
