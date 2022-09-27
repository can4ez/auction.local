import Axios from 'axios'
import config from '@/../config'

const state = {
    users: null,
    user: null
};

const actions = {
  
  GET_ALL_USERS({commit}, data){
    return Axios.get(config.apiUrl + '/users', {
      method: "GET"
    }).then((users) => {
      commit('SET_ALL', users.data);
      return users;
    }).catch((error)=>{
      console.log(error);
      return error;
    });
  },

    TRY_LOGIN({commit}, data){
      return Axios.get(config.apiUrl + '/users/login', {
        method: "POST",
        params:{ email: data.email , password: data.password }
      }).then((user) => {
        commit('SET_USER', user.data);
        return user;
      }).catch((error)=>{
        console.log(error);
        return error;
      });
    },
    TRY_REGISTER({commit}, data){
      console.log(data.email, data.password);
      return Axios.get(config.apiUrl + '/users/login', {
        method: "POST",
        params:{ email: data.email , password: data.password }
      }).then((user) => {
        return user;
      }).catch((error)=>{
        console.log(error);
        return error;
      });
    }

};

const mutations = {
  SET_USER(state, user){
    state.user = user;
  },
  SET_ALL(state, users){
    state.users = users;
  },
};

const getters = {
  USER(state){
    return state.user ?? {};
  },
  USER_BY_ID: (state) => (id) => {
    if(state.users == null){
      return {};
    }

    return state.users.find((usr)=>{ 
      if(usr.id == id)
        return usr;
     });
  }
}


export const users = {
    namespaced: true,
    state,
    actions,
    mutations,
    getters
};
