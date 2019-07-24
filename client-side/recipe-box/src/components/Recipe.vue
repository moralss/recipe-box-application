<template>
  <div>
    <h3>
      <strong>RECIPE NAME : </strong>
      <span>{{recipe.recipeName}}</span>
    </h3>
    <Ingredients :recipeId="recipe.id"></Ingredients>
    <button @click="removeRecipe(recipe.id)">DELETE</button>
    <button @click="changeIsEdited(recipe)">EDIT</button>
  </div>
</template>
<script>
import { mapMutations, mapActions } from "vuex";
import { TOGGLE_IS_EDIT } from "../store/types";
export default {
  name: "Recipe",
  props: ["recipe"],
  components: {
     Ingredients: require("./Ingredients").default
  },
  methods: {
    ...mapActions(["removeRecipe"]),
    ...mapMutations({"changeIsEdited" : TOGGLE_IS_EDIT}),
    removeRecipe(id) {
      this.$store.dispatch("removeRecipe", id);
    }
  }
};
</script>
<style>
button{
  margin:1rem;
  padding:0.5rem;
}

label{
  margin-left:1rem;
  margin-right:1rem;
}

button:hover{
  color:grey;
}

strong{
  color:green;
}

h1{
   color:Navy;
}
small{
  color:green;
}

input{
  padding:0.6rem;
}
</style>
