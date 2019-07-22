<template>
  <div class="container">
    <div>
      <h1>List of Recipes</h1>
      <Recipe v-for="(recipe , id) in recipes" 
      :key="id" :recipe="recipe"
      :id="id"></Recipe>
    </div>
    <div>
      <Add ></Add>
      <Edit></Edit>
    </div>
  </div>
</template>

<script>
import { mapGetters} from "vuex";
import { mapActions} from "vuex";
export default {
  name: "Recipes",
  computed: {
    ...mapGetters({
      recipes: "getRecipes"
    })
  },
  components: {
    Recipe: require("./Recipe").default,
    Add: require("./Add").default,
    Edit: require("./Edit").default
  },
  methods: {
    ...mapActions(["fetchRecipes"])
  },
  created: function() {
    this.$store.dispatch("fetchRecipes");
  }
};
</script>
<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>
.container{
  display:grid;
  grid-template-columns:repeat(2 , 1fr);
}

.label{
  margin:2rem;
}

.input{
  margin:2rem;
}

html{
  font-weight:300;
}

</style>
