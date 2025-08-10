<script lang="ts">
import 'leaflet'
import { fetchHazards } from '@/api/hazardApi'
import { geoJSON, latLng } from 'leaflet'
import { LMap, LTileLayer, LGeoJson } from '@vue-leaflet/vue-leaflet'

export default {
  name: 'hazard',
  components: {
    LGeoJson,
    LTileLayer,
  },
  data() {
    return {
      data: null,
      url: 'https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png',
      attribution:
        '&copy; <a target="_blank" href="http://osm.org/copyright">OpenStreetMap</a> contributors',
      zoom: 8,
      center: [47.31322, -1.319482],
      geojson: null,
    }
  },
  methods: {
    async fetchData() {
      try {
        // this.data = await fetchHazards()
        this.geojson = await fetchHazards()
      } catch (error) {
        console.error('Error fetching data:', error)
      }
    },
  },
}
</script>

<template>
  <!-- <l-map style="height: 350px" :zoom="zoom" :center="center">
    <l-tile-layer :url="url" :attribution="attribution"></l-tile-layer>
    <l-geo-json :geojson="geojson"></l-geo-json>
  </l-map> -->
  <div>
    <h1>Hazard Test</h1>
    <p>Click the button to fetch data with an HTTP request.</p>
    <button @click="fetchData">Fetch data</button>
    <pre v-if="data">{{ data }}</pre>
  </div>
</template>
