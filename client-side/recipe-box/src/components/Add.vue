<template>
  <div>
    <h1> Add Recipe </h1>
    <label for>Recipe Name</label>
    <input type="text" v-model="recipeName" placeholder="recipeName" />
    <button @click="addNewRecipe()">submit</button>
  </div>
</template>
<script>
import { mapActions } from "vuex";
export default {
  name: "Add",
  data() {
    return {
      recipeName: ""
      };
  },
  methods: {
    ...mapActions(["addRecipe"]),
    ...mapActions(["fetchRecipes"]),
    addNewRecipe() {
      this.$store.dispatch("addRecipe", {recipeName :  this.recipeName });
      this.recipeName = "";
    }
  }
};
</script>
<style >
</style>
