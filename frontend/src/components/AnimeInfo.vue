<script lang="ts" setup>
import type { Anime } from '@/models/anime'
import { computed } from 'vue'
import duration from 'dayjs/plugin/duration'
import dayjs from 'dayjs'

dayjs.extend(duration)

const props =
  defineProps<
    Pick<
      Anime,
      'season' | 'seasonYear' | 'source' | 'description' | 'status' | 'episodeCount' | 'duration'
    >
  >()

const source = computed(() => {
  switch (props.source) {
    case 'LightNovel':
      return 'Light Novel'
    case 'VisualNovel':
      return 'Visual Novel'
    case 'VideoGame':
      return 'Video Game'
    case 'WebNovel':
      return 'Web Novel'
    case 'LiveAction':
      return 'Live Action'
    case 'MultimediaProject':
      return 'Multimedia Project'
    case 'PictureBook':
      return 'Picture Book'
    default:
      return props.source
  }
})

const status = computed(() => {
  switch (props.status) {
    case 'NotYetReleased':
      return 'Not Yet Released'
    default:
      return props.status
  }
})

const episodeCountAndDuration = computed(() => {
  const duration = dayjs.duration(props.duration ?? 0, 'minutes')
  const durationString = duration.hours() >= 1 ? duration.format('H[h] m[m]') : duration.format('m[m]')

  if (props.episodeCount != 1) {
    return `${props.episodeCount ?? '?'} eps × ${durationString}`
  } else {
    return durationString
  }
})
</script>

<template>
  <div class="anime-info">
    <div class="anime-date-and-episodes">
      <span> {{ season }} {{ seasonYear }} </span>

      <span>
        {{ episodeCountAndDuration }}
      </span>
    </div>

    <div class="anime-metadata">
      <div class="anime-source-and-status">
        <span>{{ source }} </span>
        <span> {{ status }}</span>
      </div>
    </div>

    <div class="anime-synopsis">
      <p v-html="description"></p>
    </div>
  </div>
</template>

<style scoped>
.anime-metadata,
.anime-date-and-episodes {
  padding: 5px 0;
  background-color: rgba(30, 30, 30, 0.2);
  border-bottom: 1px solid rgba(253, 253, 253, 0.1);
}

.anime-date-and-episodes, .anime-source-and-status {
  * {
    vertical-align: middle;
    display: inline-block;
    width: 50%;
  }
}

.anime-synopsis {
  line-height: 1.2;
  overflow-y: hidden;
  padding: 0.5em;
  text-align: left;
  white-space: normal;
  color: #fdfdfd;
  flex: 1;
  -webkit-user-select: none;
  -moz-user-select: none;
  user-select: none;
  scrollbar-width: thin;
  scrollbar-gutter: stable;
  will-change: overflow-y, user-select;
}

.anime-synopsis p:last-child {
  margin: 0;
}

.anime-synopsis:hover {
  overflow-y: scroll;
  -webkit-user-select: text;
  -moz-user-select: text;
  user-select: text;
}

.anime-info {
  color: rgba(253, 253, 253, 0.6);
}

.anime-info {
  display: flex;
  flex-flow: column;
  height: 192.8571428571px;
  max-height: 192.8571428571px;
}

@media print, screen and (min-width: 40em) {
  .anime-info {
    height: 250px;
    max-height: 250px;
  }
}
</style>
