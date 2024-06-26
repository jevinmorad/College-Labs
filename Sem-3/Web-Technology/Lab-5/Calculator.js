clear = false
isBackspace = true
isBracketOn = true
function add(val) {
    ans = document.getElementById('display')
    if (clear) {
        ans.value = ""
        clear = false
    }
    ans.value += val
    isBackspace = true
}
function equal() {
    ans = document.getElementById('display')
    disp = eval(ans.value)
    ans.value = disp
    clear = true
    isBackspace = false
}
function cls() {
    clr = document.getElementById('display')
    clr.value = " "
}
function backspace() {
    if (isBackspace) {
        num = document.getElementById('display')
        data = num.value
        num.value = data.slice(0, -1);
    }
}
function addBrecket(){
    if (isBracketOn) {
        add('(')
        isBracketOn = false
    }
    else{
        add(')')
        isBracketOn = true
    }
}