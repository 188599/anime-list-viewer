export interface Anime {
    id: number
    title: {
        native: string
        romaji?: string
        english?: string
    }
    episodeCount?: number
    duration?: number
    status: string
    description: string
    imageUrl: string
    genres: string[]
    source: string
    seasonYear: number
    season: string
    averageScore: number
}
