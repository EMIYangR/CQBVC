const allScore = []
let totalCount = {
    short: 0,
    long: 0,
}
let render = null
let rmDialog = null
async function getScore(next, type) {

    let url = `https://api.bilibili.com/pgc/review/${type}/list?media_id=4315402&ps=12575&sort=0`

    if (next) {
        url += `&cursor=${next}`
    }
    const res = await fetch(url, { "method": "GET" });
    const { data } = await res.json()
    if (totalCount[type] == 0) {
        totalCount[type] = data.total
    }
    return data
}

async function scoreMain(type) {
    let { list, next } = await getScore(undefined, type)
    handlerList(list)

    while (true) {
        const data = await getScore(next, type)
        handlerList(data.list)
        render(type)
        next = data.next
        if (next == 0) {
            return
        }
    }
}
function average() {
    const total = allScore.reduce((p, v) => {
        return p + v
    }, 0)
    const s = total / allScore.length
    const sf = s.toFixed(1)
    document.getElementsByClassName("media-info-score-content")[0].innerText = sf
    console.log('平均分:', sf)
}
function handlerList(list) {
    allScore.push(...list.map(item => item.score))
}
function beforeRender() {
    const dialog = document.createElement('div')
    document.body.appendChild(dialog)
    dialog.style.position = 'fixed'
    dialog.style.width = '100%'
    dialog.style.height = '100%'
    dialog.style.background = 'rgba(0,0,0,.8)'
    dialog.style.top = '0'
    dialog.style.left = '0'
    dialog.style.zIndex = '999'
    dialog.style.display = 'flex'
    dialog.style.alignItems = 'center'
    dialog.style.justifyContent = 'center'


    const dialogContent = document.createElement('div')
    dialog.appendChild(dialogContent)

    dialogContent.style.width = '455px'
    dialogContent.style.height = '200px'
    dialogContent.style.background = '#fff'
    dialogContent.style.borderRadius = '6px'
    dialogContent.style.padding = '51px 0'

    const shortWrap = document.createElement('div')
    dialogContent.appendChild(shortWrap)
    const longWrap = document.createElement('div')
    dialogContent.appendChild(longWrap)

    shortWrap.style.width = longWrap.style.width = '455px'
    shortWrap.style.height = longWrap.style.height = '100px'
    shortWrap.style.display = longWrap.style.display = 'flex'
    shortWrap.style.alignItems = longWrap.style.alignItems = 'center'
    shortWrap.style.justifyContent = longWrap.style.justifyContent = 'center'

    // --------------
    const shortw1 = document.createElement('div')
    const longw1 = document.createElement('div')
    shortWrap.appendChild(shortw1)
    longWrap.appendChild(longw1)
    shortw1.innerText = '短评:'
    longw1.innerText = '长评:'
    longw1.style.fontSize = shortw1.style.fontSize = '14px'
    longw1.style.color = shortw1.style.color = '#333'
    longw1.style.marginRight = shortw1.style.marginRight = '16px'


    const shortw2 = document.createElement('div')
    const longw2 = document.createElement('div')
    shortWrap.appendChild(shortw2)
    longWrap.appendChild(longw2)
    longw2.style.width = shortw2.style.width = '300px'
    longw2.style.height = shortw2.style.height = '32px'
    longw2.style.background = shortw2.style.background = '#eee'
    longw2.style.position = shortw2.style.position = 'relative'


    const shortPrg = document.createElement('div')
    const longPrg = document.createElement('div')
    shortw2.appendChild(shortPrg)
    longw2.appendChild(longPrg)

    longPrg.style.position = shortPrg.style.position = 'absolute'
    longPrg.style.left = shortPrg.style.left = '0'
    longPrg.style.top = shortPrg.style.top = '0'
    longPrg.style.width = shortPrg.style.width = '0%'
    longPrg.style.height = shortPrg.style.height = '100%'
    longPrg.style.background = shortPrg.style.background = '#ff85ad'


    render = function (type) {
        const dom = type == 'long' ? longPrg : shortPrg
        let width;
        if (type == 'long') {
            width = ((allScore.length - totalCount.short) * 100 / totalCount.long) + '%'
        } else {
            width = (allScore.length * 100 / totalCount.short) + '%'
        }
        dom.style.width = width
    }

    rmDialog = function () {
        document.body.removeChild(dialog)
    }
}


async function main() {
    beforeRender()
    console.log("--统计短评");
    await scoreMain('short')
    console.log("--统计长评");
    await scoreMain('long')
    average()
    rmDialog()
}
main()
