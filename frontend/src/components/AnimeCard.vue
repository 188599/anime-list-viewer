<script setup lang="ts">
import { computed } from 'vue'
import AnimePoster from './AnimePoster.vue'
import AnimeGenres from './AnimeGenres.vue'
import AnimeInfo from './AnimeInfo.vue'
import type { Anime } from '@/models/anime'

const props = defineProps<Anime>()

const title = computed(() => props.title.english ?? props.title.romaji ?? props.title.native)
</script>

<template>
  <article class="anime">
    <div class="anime-card">
      <h3 class="main-title">{{ title }}</h3>

      <AnimeGenres :genres />

      <AnimePoster :title :imageUrl :averageScore />

      <AnimeInfo :season :seasonYear :episodeCount :duration :source :status :description />
    </div>
  </article>
</template>

<style scoped>
.anime {
  display: inline-block;
  padding: 0 1rem 1rem 0;
  position: relative;
  vertical-align: top;
  white-space: nowrap;
  width: 16.6666666667%;
  font-size: 14px;
}

.anime-card {
  box-shadow: 0 1px 4px rgba(0, 0, 0, 0.2);
  background-color: #1e1e1e;
  background-color: var(--lc-current-mark-bg-color, #1e1e1e);
  font-size: 0.9em;
  line-height: 1;
  overflow: hidden;
  text-align: center;
  border-radius: 5px;
}

.main-title {
  z-index: 1;
  position: relative;
}

.main-title {
  font-size: 1.2em;
  line-height: 1.1;
  min-height: 1.2em;
  margin: 0;
  padding: 0 1rem;
  display: flex;
  font-weight: bold;
  align-items: center;
  white-space: initial;
}

.main-title {
  min-height: 2.4em;
  padding: 0 1.2rem;
  text-overflow: ellipsis;
  overflow: hidden;
  -webkit-box-orient: vertical;
  display: -webkit-box;
  line-clamp: 2;
  -webkit-line-clamp: 2;
  align-content: center;
}

.main-title a {
  margin: 0 auto;
}

.main-title:hover {
  text-overflow: initial;
  white-space: normal;
}

/* .anime-card .episode-countdown {
  background: rgba(0, 0, 0, 0.65);
  top: 0;
  padding: 0.2em 0;
  width: 100%;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;
  -webkit-backdrop-filter: blur(8px);
  backdrop-filter: blur(8px);
}

.anime-card .release-schedule-info {
  font-size: 90%;
  padding-bottom: 2px;
  opacity: 0.75;
  font-weight: bold;
  overflow: hidden;
  text-overflow: ellipsis;
} 

.anime-card .spoiler-warning {
  height: 0px;
  left: unset;
  top: 1rem;
  position: sticky;
  transform: unset;
}  
*/

@media screen and (max-width: 160em) {
  .anime {
    width: 20%;
  }
}

@media screen and (max-width: 120em) {
  .anime {
    width: 25%;
  }
}

@media screen and (max-width: 92em) {
  .anime {
    width: 33.3333333333%;
  }
}

@media print, screen and (max-width: 74.99875em) {
  .anime {
    width: 50%;
  }
}

@media print, screen and (max-width: 63.99875em) {
  .anime {
    white-space: normal;
  }
}

@media print, screen and (max-width: 39.99875em) {
  .anime {
    width: 100%;
    display: block;
    padding-right: 0px;
  }

  .main-title {
    padding: 0.5em 2em;
  }
}
</style>
