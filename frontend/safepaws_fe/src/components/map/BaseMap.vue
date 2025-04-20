<template>
  <div style="height: 600px; width: 800px">
    <l-map ref="map" v-model:zoom="zoom" :center="[43.47, -80.51]">
      <l-tile-layer :url="url" :attribution="attribution" name="OpenStreetMap"></l-tile-layer>
    </l-map>
  </div>
</template>

<script lang="ts">
import 'leaflet'
import 'leaflet/dist/leaflet.css'
import { LMap, LTileLayer } from '@vue-leaflet/vue-leaflet'

export default {
  components: {
    LMap,
    LTileLayer,
  },
  data() {
    return {
      url: 'https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png',
      attribution:
        '&copy; <a target="_blank" href="http://osm.org/copyright">OpenStreetMap</a> contributors',
      zoom: 11,
      geojson: null,
    }
  },
}
</script>

<style></style>
