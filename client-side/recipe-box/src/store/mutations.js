import * as types from './types';

 export const mutations =  { 
     [types.ADD_RECIPE] :  (state , payload) => {
        state.recipes.push(payload);
 },
    [types.DELETE_RECIPE]: (state , id ) => {
            state.recipes.forEach((recipe , index) => {
             if(recipe.id == id){
                state.recipes.splice(index , 1);
             }
        });
    },
    [types.ADD_INGREDIENTS] : (state , payload) => {
        state.ingredients.push(payload);
    },
    [types.FETCH_INGREDIENTS] : (state , payload) => {
        state.ingredients.push(...payload);

    },
    [types.EDIT_RECIPE]: (state ,payload) => {
            for (var i in state.recipes) {
            if (i == payload.index) {
                state.recipes[i].recipeName = payload.recipeName;
                state.recipes[i].ingredients = payload.ingredients;
                break; 
            }
        }
    },
    [types.TOGGLE_IS_EDIT] : (state , payload) => {
        state.recipeToEdit = payload;    
    },
    [types.FETCH_RECIPES] : (state , payload) => {
      state.recipes.push(...payload);  
},
}


