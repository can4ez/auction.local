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
    commit
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
      /* TODO: Какой формат ответа? */
      if (response.status == 201)
        return response.data; /* TODO: Тут вроде вернет данные пользователя */
      else
        return false; /* TODO: Обработать ошибку регистрации */
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
        email: data.email, //"hd.anufriev@yandex.ru",
        password: data.password, //"123456",
      }
    }).then((response) => {
      if (response.status == 200) {
        commit('SET_USER', state.users.find((e) => {
          return e.email == data.email;
        }));
        return true;
      } else if (response.status == 204) {
        return false; /* TODO: Обработать ошибку регистрации */
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
    state.user = null;
  }

};

const mutations = {
  SET_USER(state, user) {
    state.user = user;
  },
  SET_ALL(state, users) {
    state.users = users;
  },
};

const getters = {
  USER(state) {
    return state.user ?? {};
  },
  USER_BY_ID: (state) => (id) => {
    if (state.users == null) {
      return {};
    }

    return state.users.find((usr) => {
      if (usr.id == id)
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
