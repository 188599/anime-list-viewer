<script setup lang="ts">
import type { Anime } from '@/models/anime'

defineProps<Pick<Anime, 'genres'>>()
</script>

<template>
  <ol class="anime-tags">
    <li v-for="(genre, index) in genres" :key="index">
      {{ genre }}
    </li>
  </ol>
</template>

<style scoped>
.anime-tags {
  color: rgba(253, 253, 253, 0.6);
}

.anime-tags {
  z-index: 1;
  position: relative;
}

.anime-tags {
  margin: 0;
  padding: 0;
  list-style: none;
  --lc-list-delimiter: ' · ';
  border-bottom: 1px solid rgba(253, 253, 253, 0.1);
}

.anime-tags > li {
  display: inline-block;
}

.anime-tags > li + li::before {
  white-space: pre;
  content: var(--lc-list-delimiter);
}

.anime-tags a {
  color: rgba(253, 253, 253, 0.6);
}

.anime-tags a:hover {
  text-decoration: underline;
  color: #95ccff;
}

@media print, screen and (min-width: 40em) {
  .anime-tags {
    overflow: hidden;
    white-space: nowrap;
    text-overflow: ellipsis;
  }
}
</style>
