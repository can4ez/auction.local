<template>
  <div class='mini_profile'>
    <router-link class="mini_profile__welcome" :to="{ name: 'login'}">
      Привет, <span class="user">{{USER_NAME}}</span>
    </router-link>
    
    <router-link class="mini_profile__register" :to="{ name: 'reg'}" v-if="USER.id == null">
      Зарегистрироваться
    </router-link>
    <router-link class="mini_profile__login" :to="{ name: 'login'}" v-if="USER.id == null">
      Войти
    </router-link>
    
    <router-link class="mini_profile__profile" :to="{ name: 'profile'}" v-if="USER.id != null">
      Мой профиль
    </router-link>
    <router-link class="mini_profile__auction" :to="{ name: 'createAuction'}" v-if="USER.id != null">
      Новый аукцион
    </router-link>
    <router-link class="mini_profile__logout" :to="{ name: 'logout'}" v-if="USER.id != null">
      Выйти
    </router-link>

  </div>
</template>

<script>
import { mapGetters } from 'vuex';

export default {
  data() {
    return {
    }
  },
  components: {},
  computed: {
    ...mapGetters('users', ['USER']),

    USER_NAME() { return this.USER.name ?? 'Гость' }
  },
  methods: {
  },
  mounted() { }
}
</script>

<style lang='scss'>
.mini_profile {
  display: flex;
  flex-direction: column;

  a {
    color: var(--color-link);
    text-decoration: none;
    padding: .2em 0;
  }

  &__welcome {
    .user {
      text-decoration: underline double currentcolor auto;
    }
  }

  &__register {}

  &__login {}
}
</style>
