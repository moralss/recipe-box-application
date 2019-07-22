<template>
  <div>
    <h1> Edit Recipe Item</h1>
    <label for>recipeName</label>
    <input type="text" v-model="editRecipe.recipeName" placeholder="recipeName" />
    <label for>ingredient</label>
    <input type="text" v-model="editRecipe.ingredients" placeholder="ingredient" />
    <button @click="submitEditedRecipe(editRecipe.recipeName , editRecipe.ingredients)">submit</button>
  </div>
</template>
<script>
import { mapActions , mapGetters } from "vuex";

export default {
  name: "Edit",
  props: ["recipe"],
  computed: {
    ...mapGetters({
      editRecipe: "getEditRecipe"
    })
  },
  methods: {
    ...mapActions(["editRecipe"]),
    submitEditedRecipe(recipeName, ingredients) {
      const recipeInfo = { recipeName, ingredients, id: this.editRecipe.id};
      this.$store.dispatch("editRecipe", recipeInfo);

    }
  }
}
</script>
<style scoped>
</style>
