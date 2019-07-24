import * as types from "./types";
import axios from "axios";

export const actions = {
  addRecipe: async ({ commit }, payload) => {
      try {
      let {data} = await axios.post("https://localhost:44353/api/recipe", {
        ...payload
      });
      commit(types.ADD_RECIPE , data.object);
    } catch (e) {
      throw e;
    }
  },
  removeRecipe: async ({ commit }, id) => {
    try{
      await axios.delete(`https://localhost:44353/api/recipe/${id}`)
      commit(types.DELETE_RECIPE, id);
    }catch(e){
      throw e;
    }
  },
  editRecipe: async ({ commit}, payload) => {
    try {
      await axios.put(`https://localhost:44353/api/recipe`, {
        ...payload
      });
      commit(types.EDIT_RECIPE, payload);
    } catch (e) {
      throw e;
    }
  },
  fetchRecipes: async ({ commit }) => {
    try {
      let { data } = await axios.get("https://localhost:44353/api/recipe");
      commit(types.FETCH_RECIPES, data);
    } catch (e) {
      throw e;
    }
  },
  fetchIngredient: async ({commit} , id) => {
    try {
      let { data } = await axios.get(`https://localhost:44353/api/ingredient/${id}`);
      commit(types.FETCH_INGREDIENTS, data);
    } catch (e) {
      throw e;
    }
  },
  addIngredient: async ({ commit }, payload) => {
    try {
    let { data } = await axios.post("https://localhost:44353/api/ingredient", {
      ...payload
    });
    commit(types.ADD_INGREDIENTS, data.object);
  } catch (e) {
    throw e;
  } 
}
};
