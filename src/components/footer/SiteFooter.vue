<template>
    <footer class='footer'>
        <div class="footer__row">
            <div class="footer__column">
                <div>
                    Контактные данные<br>
                    +792222255 <br>
                    mailto@mail.ru
                </div>
            </div>
            <div class="footer__column">
                <div>
                    Наши сотрудники <br>
                    Крутая компания _ 1 <br>
                    Крутая компания _ 2
                </div>
            </div>
            <div class="footer__column">
                <div>
                    <router-link :to="{ name: 'faq'}" class="navbar__item column"> Инструкция </router-link>
                </div>

            </div>
        </div>
    </footer>
</template>

<script>
export default {
    data() {
        return {
        }
    },
    components: {},
    computed: {},
    methods: {
    },
    mounted() { }
}
</script>

<style lang='scss' scoped>
.footer {
    margin-top: 1rem;
    padding: 1rem;
    background-color: var(--color-footer-bg);
    color: var(--color-footer-text);

    &__row {
        display: flex;
    }

    &__column {
        margin-left: 1rem;
    }

    a{
        color: white;
    }
}
</style>
