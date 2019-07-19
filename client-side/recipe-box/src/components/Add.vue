<template>
  <div>
    <label for>Recipe Name</label>
    <input type="text" v-model="recipeName" placeholder="recipeName" />
    <label for>Ingredient</label>
    <input type="text" v-model="ingredients" placeholder="ingredient" />
    <button @click="addNewRecipe()">submit</button>
  </div>
</template>
<script>
import { mapActions } from "vuex";
export default {
  name: "Add",
  data() {
    return {
      recipeName: "",
      ingredients: ""
    };
  },
  methods: {
    ...mapActions(["addRecipe"]),
    ...mapActions(["fetchRecipes"]),
    addNewRecipe() {
        const newRecipe = {
        recipeName: this.recipeName,
        ingredients: this.ingredients,
      };
      this.$store.dispatch("addRecipe", newRecipe);
      this.recipeName = "";
      this.ingredients = "";
    }
  }
};
</script>
<style >
</style>
