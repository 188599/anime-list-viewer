<script lang="ts" setup>
import type { Anime } from '@/models/anime'
import { computed } from 'vue'

const props = defineProps<Pick<Anime, 'imageUrl' | 'averageScore'> & { title: string }>()

const averageScore = computed(() => {
  return props.averageScore ? (props.averageScore / 10).toFixed(2) : 'N/A'
})
</script>

<template>
  <div class="poster-container">
    <img :src="imageUrl" :alt="title" />

    <div class="anime-extras">
      <div class="anime-avg-user-rating">
        ⭐
        {{ averageScore }}
      </div>
    </div>
  </div>
</template>

<style scoped>
.poster-container {
  border-right: 1px solid rgba(253, 253, 253, 0.1);
  float: left;
  width: 136px;
  position: relative;
  overflow: hidden;
}

.poster-container:hover .anime-extras:not(:hover),
.poster-container:hover .episode-countdown:not(:hover) {
  opacity: 0;
}

.anime-card .episode-countdown,
.anime-card .anime-extras {
  transition: opacity 0.15s linear;
  left: 0;
  position: absolute;
  font-size: 0.95em;
  color: #fff;
  z-index: 5;
}

.anime-extras {
  bottom: 0;
}

@media print, screen and (min-width: 40em) {
  .poster-container {
    width: 176px;
    height: 250px;
  }
}

.anime-extra,
.anime-avg-user-rating {
  float: left;
  clear: left;
  margin-bottom: 0.5em;
}

.anime-avg-user-rating {
  padding: 0.5em 1em 0.5em 1em;
  background: rgba(0, 0, 0, 0.65);
  border-radius: 20em;
  margin-left: 0.5em;
  cursor: pointer;
}

img {
  display: inline-block;
  vertical-align: middle;
  max-width: 100%;
  height: auto;
  -ms-interpolation-mode: bicubic;
}
</style>
