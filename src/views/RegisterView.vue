<template>
  <div class='registerView'>
    <div class="box">
      <!-- <form> -->
      <div class="field" v-if="this.errors == true">
        <article class="message is-danger">
          <div class="message-header">
            <p>Ошибка регистрации: {{errorMsg}}</p>
            <button class="delete" aria-label="delete" v-on:click="this.errors = false"></button>
          </div>
        </article>
      </div>

      <div class="field">
        <div class="control">
          <input class="input is-large" type="text" placeholder="Имя" autofocus="" v-model="name">
        </div>
      </div>
      <div class="field">
        <div class="control">
          <input class="input is-large" type="email" placeholder="Почта" autofocus="" v-model="email">
        </div>
      </div>

      <div class="field">
        <div class="control">
          <input class="input is-large" type="password" placeholder="Пароль" v-model="password">
        </div>
      </div>

      <div class="field">
        <div class="control">
          <input class="input is-large" type="password" placeholder="Повторите пароль" v-model="password2">
        </div>
      </div>
      <div class="button is-block is-primary is-large is-fullwidth" @click="doRegister()">Зарегистрироваться</div>
      <!-- </form> -->
    </div>
  </div>
</template>

<script>
import { mapActions } from 'vuex';
export default {
  data() {
    return {
      name: "Александр",
      email: "test@mail.ru", password: "12345678", password2: "12345678",
      errors: false
    }
  },
  components: {},
  computed: {},
  methods: {
    ...mapActions('users', ['userRegister']),
    doRegister: function () {

      if (this.password2 !== this.password) {
        this.errors = true;
        this.errorMsg = "Пароли не совпадают";
        return;
      }

      this.userRegister(this).then((result) => {
        if (result != true) {
          this.errors = true;
          this.errorMsg = result;
          return;
        }

        this.$router.push({ name: 'login' })

      });
    }
  },
  mounted() { }
}
</script>

<style lang='scss'>
.registerView {
  display: flex;
  justify-content: center;
}

.registerView .box {
  width: 50%;
}
</style>
