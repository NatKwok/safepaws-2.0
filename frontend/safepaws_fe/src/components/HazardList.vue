<template>
  <h1>Hazard Test</h1>
  <p>Click the button to fetch data with an HTTP request.</p>
  <button @click="fetchData">Fetch data</button>
  <pre v-if="data">{{ data }}</pre>
</template>

<script lang="ts">
import { fetchHazards } from '@/api/hazardApi'
export default {
  data() {
    return {
      data: null,
    }
  },
  methods: {
    async fetchData() {
      try {
        this.data = await fetchHazards()
      } catch (error) {
        console.error('Error fetching data:', error)
      }
    },
  },
}
</script>
