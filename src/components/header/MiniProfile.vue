<template>
    <div class='mini_profile'>
        <router-link class="mini_profile__welcome" :to="{ name: 'login'}">
          Привет, <span class="user">{{USER_NAME}}</span>
        </router-link>
        <router-link class="mini_profile__register"
        :to="{ name: 'reg'}">
          Зарегистрироваться
        </router-link>
        <router-link class="mini_profile__login"
          :to="{ name: 'login'}">
          Войти
        </router-link>
    </div>
</template>

<script>
  import { mapGetters } from 'vuex';
  
export default {
  data () {
    return {
    }
  },
  components: { },
  computed: {
    ...mapGetters('users', ['USER']),

    USER_NAME () { return this.USER.id ?? 'Гость' }
  },
  methods: {
  },
  mounted () { }
}
</script>

<style lang='scss'>
    .mini_profile{
      display: flex;
      flex-direction: column;
      a{
color: var(--color-link);
            text-decoration: none;
            padding: .2em 0;
      }
        &__welcome{
          .user{
            text-decoration: underline double currentcolor auto;
          }
        }
        &__register{}
        &__login{}
    }
</style>
