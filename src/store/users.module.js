import Axios from 'axios'
import config from '@/../config'

const usersApi = config.apiUrl + '/user';

const userRegisterApi = usersApi + '/register';
const userAuthApi = usersApi + '/auth';
const userListApi = usersApi + '/list';
const userProfileApi = usersApi + 'info/';

const state = {
  users: null,
  user: null
};

const actions = {

  userRegister({
    commit, actions
  }, data) {
    return Axios({
      url: userRegisterApi,
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      data: {
        email: data.email, //"hd.anufriev@yandex.ru",
        password: data.password, //"123456",
        name: data.name, //"Dmitrii"
      }
    }).then((response) => {
      actions.userList();
      if (response.status == 201)
        return true;
      else
        return response;
    }).catch((error) => {
      console.log(error);
      return error;
    });
  },

  userAuth({
    commit,
    state
  }, data) {
    return Axios({
      url: userAuthApi,
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      data: {
        email: data.email,
        password: data.password,
      }
    }).then((response) => {
      if (response.status == 200) {
        commit('SET_USER', state.users.find((e) => {
          return e.email == data.email;
        }));
        return true;
      } else if (response.status == 204) {
        return false;
      }
    }).catch((error) => {
      console.log(error);
      return error;
    });
  },

  userList({
    commit
  }, data) {
    return Axios(userListApi, {
      method: "GET"
    }).then((response) => {

      if (response.status == 200) {
        /* TODO: Вернет список пользователей */
        commit('SET_ALL', response.data);
        return true;
      } else {
        return false;
      }

    }).catch((error) => {
      console.log(error);
      return error;
    });
  },

  /* TODO: Какой формат запроса? */
  userProfile({
    commit
  }, data) {
    return Axios(userProfileApi + data.id, {
      method: "GET"
    }).then((response) => {
      if (response.status == 200) {
        /* TODO: Вернет объект пользователя */
        return response.data;
      } else {
        return false;
      }
    }).catch((error) => {
      console.log(error);
      return error;
    });
  },

  logOut({commit, state}){
    localStorage.user = null;
    state.user = null;
  },

  
  getUserByID({commit, state, actions}, id){

    const findUser = (id) => {
      return state.users.find((usr) => {
        if (usr.id == id)
          return usr;
        });
    };

    if (state.users == null) {
      return actions.userList().then((result)=>{
          return findUser(id);
      });
    }

    return findUser(id);
  }

};

const mutations = {
  SET_USER(state, user) {
    state.user = user;
    localStorage.user = JSON.stringify(user);
  },
  SET_ALL(state, users) {
    state.users = users;
  },
};

const getters = {
  USER(state) {
    if (!state.user) {
      if (localStorage.user) {
        try{state.user = JSON.parse (localStorage.user);}
        catch (e) {
          state.user = null;
          localStorage.user = null;
        }
      }
    }

    return state.user ?? {};
  },
  USERS(state) {
    return state.users ?? {};
  }
}


export const users = {
  namespaced: true,
  state,
  actions,
  mutations,
  getters
};
