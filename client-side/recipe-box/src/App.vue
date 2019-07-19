<template>
  <div id="app">
    <Recipes />
  </div>
</template>

<script>
import Recipes from './components/Recipes.vue'


export default {
  name: 'app',
  components: {
    Recipes,
  }
}
</script>

<style>
  body{
    text-align:center;
  }

  body > div{
    margin:3rem;
    font-weight: 300;
  }
</style>
