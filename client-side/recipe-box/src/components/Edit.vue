<template>
  <div>
    <h1> Edit Recipe Name</h1>
    <label for>recipeName</label>
    <input type="text" v-model="editRecipe.recipeName" placeholder="recipeName" />
    <button @click="submitEditedRecipe(editRecipe.recipeName)">submit</button>
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
    submitEditedRecipe(recipeName) {
      const recipeInfo = { recipeName, id: this.editRecipe.id};
      this.$store.dispatch("editRecipe", recipeInfo);
    }
  }
}
</script>
<style scoped>
</style>
