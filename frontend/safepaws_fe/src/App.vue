<template>
  <header>
    <img alt="Vue logo" class="logo" src="./assets/logo.svg" width="125" height="125" />

    <div class="wrapper">
      <HelloWorld msg="You did it!" />
    </div>

  </header>

  <main>
    <div>
    Welcome To SafePaws
    	<i>Description: </i> This application is useful for determining the best path to walk you're dog. Hazards such as trash and glass are identified as well as trails, dog parks and dog friendly institutions	</br><b><i> Happy with your edits? export and send it to safepaws@gmail.com to be added to the application </i></b>


    </div>
    <div>
    <BaseMap />
    </div>



  </main>
</template>

<script setup lang="ts">
import HelloWorld from './components/HelloWorld.vue'
import TheWelcome from './components/TheWelcome.vue'
import HazardList from './components/items/HazardList.vue'
import BaseMap from './components/map/BaseMap.vue'
</script>

<style scoped>
header {
  line-height: 1.5;
}

.logo {
  display: block;
  margin: 0 auto 2rem;
}

@media (min-width: 1024px) {
  header {
    display: flex;
    place-items: center;
    padding-right: calc(var(--section-gap) / 2);
  }

  .logo {
    margin: 0 2rem 0 0;
  }

  header .wrapper {
    display: flex;
    place-items: flex-start;
    flex-wrap: wrap;
  }
}
</style>
