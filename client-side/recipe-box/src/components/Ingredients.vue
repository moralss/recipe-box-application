<template>
  <div>
    <h1>Ingredients </h1>
    <ul for v-for="(ingredient) in ingredients">
        <li v-if="ingredient.recipeId == recipeId"> {{ingredient.ingredientName}} </li>
    </ul>
    <input v-model="IngredientName" placeholder="ingredient"/>
    <button @click="addNewIngredient()"> Add Ingredient </button> 
  </div>
</template>
<script>
import {mapGetters , mapMutations, mapActions } from "vuex";
export default {
  name: "Ingredients",
  props: ["recipeId"],
  data() {
    return {
      IngredientName: ""
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
  created : function() {
    this.$store.dispatch("fetchIngredient",  this.$props.recipeId);
  },
  methods: {
    ...mapActions(["addIngredient"]),
    addNewIngredient: function() {
      this.addIngredient({Ingredient : this.IngredientName , RecipeId : this.$props.recipeId});
      this.IngredientName = "";
    }
  }
};
</script>
<style>

</style>
