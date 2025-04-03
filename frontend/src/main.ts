import './assets/main.css'

import { createApp } from 'vue'
import App from './App.vue'

const app = createApp(App)

app.provide('apiUrl', import.meta.env.API_URL ?? 'http://localhost/api')

app.mount('#app')