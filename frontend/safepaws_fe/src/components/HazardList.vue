<template>
  <h1>Hazard Test</h1>
  <p>Click the button to fetch data with an HTTP request.</p>
  <button @click="fetchData">Fetch data</button>
  <pre v-if="data">{{ data }}</pre>
</template>

<script lang="ts">
import { defineComponent, onMounted, ref } from 'vue'
import { fetchHazards } from '@/api/hazardApi'

export default defineComponent({
  name: 'MyComponent',
  setup() {
    const data = ref(null)

    onMounted(async () => {
      data.value = await fetchHazards()
    })

    return { data }
  },
})
</script>
