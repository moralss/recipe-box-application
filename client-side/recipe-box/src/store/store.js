import Vue from 'vue';
import Vuex from 'vuex';
import  {actions} from './actions'
import * as getters from './getters';
import  {mutations} from './mutations'; 

Vue.use(Vuex);


export const store = new Vuex.Store({
    state: {
        recipes: [],
        ingredients: [],
        recipeToEdit : {recipeName: "" , id : ""},
    }, 
    getters,
    mutations,
    actions 
})