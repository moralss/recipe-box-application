<template>
  <div>
    <h1>Ingredients </h1>
    <ul for v-for="(ingredient) in ingredients">
        <li v-if="ingredient.recipeId == recipeId"> {{ingredient.ingredientName}} </li>
    </ul>
    <input v-model="Ingredient" placeholder="ingredient"/>
    <button @click="addIngredient({Ingredient , RecipeId : recipeId})"> Add Ingredient </button> 
  </div>
</template>
<script>
import {mapGetters , mapMutations, mapActions } from "vuex";
export default {
  name: "Ingredients",
  props: ["recipeId"],
  data() {
    return {
      Ingredient: ""
    }
  },
  components: {
    Ingredients: require("./Ingredients").default
  },
   computed: {
    ...mapGetters({
      ingredients: "getIngredients"
    })
  },
  created : function (){
    this.$store.dispatch("fetchIngredient",  this.$props.recipeId);
  },
  methods: {
    ...mapActions(["addIngredient"])
  }
};
</script>
<style>

</style>
