export class AnimeFilter {
  title?: string
  genres?: string[]
  year?: number
  score?: string

  public static toParams(filter: AnimeFilter): URLSearchParams {
    const params = new URLSearchParams()
    if (filter.title) {
      params.append('filterByTitle', filter.title)
    }
    if (filter.genres) {
      filter.genres.forEach((genre) => {
        params.append('filterByGenre', genre)
      })
    }
    if (filter.year) {
      params.append('filterByYear', filter.year.toString())
    }
    if (filter.score) {
      const score = this.getScoreFromPattern(filter.score)!

      params.append('filterByScore', score)
    }
    return params
  }

  public static fromParams(): AnimeFilter {
    const params = new URLSearchParams(window.location.search)
    const filter = new AnimeFilter()
    const title = params.get('filterByTitle')
    if (title) {
      filter.title = title
    }
    const genres = params.getAll('filterByGenre')
    if (genres.length > 0) {
      filter.genres = genres
    }
    const year = params.get('filterByYear')
    if (year) {
      filter.year = parseInt(year)
    }
    const score = params.get('filterByScore')
    if (score) {
      filter.score = AnimeFilter.getScoreFromParams(score) ?? undefined
    }
    return filter
  }

  public static readonly scorePattern =
    /^(?:((?:[0-9](?:\.\d{1,2})?)|10)-)?((?:[0-9](?:\.\d{1,2})?)|10)$/

  public static getScoreFromPattern(value: string) {
    const match = value.match(this.scorePattern)

    if (match) {
      const value1 = match[1] != null ? parseFloat(match[1]) : null
      const value2 = match[2] != null ? parseFloat(match[2]) : null

      if (value1 != null && value2 != null) {
        return `${Math.min(value1, value2) * 10}-${Math.max(value1, value2) * 10}`
      }

      if (value1 != null || value2 != null) {
        return `${(value1 ?? value2)! * 10}`
      }
    }

    return null
  }

  public static getScoreFromParams(value: string) {
    const [min, max] = value.split('-').map((v) => parseInt(v))

    if (min && !max) {
      return `${min / 10}`
    }

    if (min && max) {
      return `${min / 10}-${max / 10}`
    }

    return null
  }
}
