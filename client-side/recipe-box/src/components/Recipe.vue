<template>
  <div>
    <h2>
      <strong>recipe name :</strong>
      {{recipe.recipeName}}
    </h2>
    <p>{{recipe.ingredients}}</p>
    <button @click="removeRecipe(recipe.id)">delete</button>
    <button @click="changeIsEdited(recipe)">edit</button>
    <!-- <Edit></Edit> -->
  </div>
</template>
<script>
import { mapMutations, mapActions } from "vuex";
import { TOGGLE_IS_EDIT } from "../store/types";
export default {
  name: "Recipe",
  props: ["recipe", "id"],

  methods: {
    ...mapActions(["removeRecipe"]),
    ...mapMutations({"changeIsEdited" : TOGGLE_IS_EDIT}),
    removeRecipe(id) {
      this.$store.dispatch("removeRecipe", id);
    }
  },
  components: {
    // Edit: require("./Edit").default
  }
};
</script>
<style>
</style>
