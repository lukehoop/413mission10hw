import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

// dev server forwards api routes to the backend so the browser stays same origin
export default defineConfig({
  plugins: [react()],
  server: {
    proxy: {
      '/api': {
        target: 'http://localhost:5088',
        changeOrigin: true,
      },
    },
  },
})
