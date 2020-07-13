import React from 'react';
import { withRouter, useHistory } from 'react-router-dom'
import {
    Drawer as MUIDrawer,
    List,
    ListItem,
    ListItemIcon,
    ListItemText,
    CssBaseline,
    AppBar,
    Toolbar,
    Typography
} from '@material-ui/core'
import {
    makeStyles,
    createStyles,
    Theme
}
    from '@material-ui/core/styles';
import InfoIcon from '@material-ui/icons/Info';
import GamesIcon from '@material-ui/icons/Games';
import PeopleIcon from '@material-ui/icons/People';

const drawerWidth = '200px';

const useStyles = makeStyles((theme: Theme) =>
    createStyles({
        appBar: {
            zIndex: theme.zIndex.drawer + 1
        },
        drawer: {
            width: drawerWidth,
            flexShrink: 0,
        },
        drawerPaper: {
            width: drawerWidth,
        },
        drawerContainer: {
            overflow: 'auto',
        }
    })
)

const Drawer = () => {
    const history = useHistory();
    const classes = useStyles();
    const itemList = [
        {
            text: 'About',
            icon: <InfoIcon />,
            onClick: () => history.push('/about')

        },
        {
            text: 'Games',
            icon: <GamesIcon />,
            onClick: () => history.push('/games')
        },
        {
            text: 'Users',
            icon: <PeopleIcon />,
            onClick: () => history.push('/users')
        },
    ];

    return (
        <>
            <CssBaseline />
            <AppBar position="fixed" className={classes.appBar}>
                <Toolbar>
                    <Typography variant="h6" noWrap>
                        Welcome to GameShelf!
                </Typography>
                </Toolbar>
            </AppBar>
            <MUIDrawer
                variant="permanent"
                className={classes.drawer}
                classes={{ paper: classes.drawerPaper }}
            >
                <Toolbar />
                <div className={classes.drawerContainer}>
                    <List>
                        {itemList.map((item, index) => {
                            const { text, icon, onClick } = item;
                            return (
                                <ListItem button key={text} onClick={onClick}>
                                    {icon && <ListItemIcon>{icon}</ListItemIcon>}
                                    <ListItemText primary={text} />
                                </ListItem>
                            )
                        })}
                    </List>
                </div>
            </MUIDrawer>
        </>
    )
}

export default withRouter(Drawer);