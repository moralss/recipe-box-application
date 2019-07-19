import * as types from './types';

 export const mutations =  { 
     [types.ADD_RECIPE] :  (state , payload) => {
        state.recipes.push(payload);
 },
    [types.DELETE_RECIPE]: (state , payload) => {
            state.recipes.splice(payload , 1);
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
}
}


