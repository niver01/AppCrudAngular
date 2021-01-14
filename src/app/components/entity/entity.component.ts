import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { IEntity } from 'src/app/models/IEntity';
import { ApiEntityService } from './../../service/api-entity.service';
import { DialogEntityComponent } from './dialog/dialog-entity.component';
import { DialogDeleteComponent } from './../../common/dialog-delete/dialog-delete.component';

@Component({
  selector: 'app-entity',
  templateUrl: './entity.component.html',
  styleUrls: ['./entity.component.scss'],
})
export class EntityComponent implements OnInit {
  @ViewChild(MatPaginator) private _paginator;
  @ViewChild(MatSort) private _sort;
  public dataSource: MatTableDataSource<IEntity>;
  public displayedColumns: string[] = [
    'IdEntidad',
    'CodigoDoc',
    'NumDocumento',
    'RazonSocial',
    'NombreComercial',
    'NombreContribuyente',
    'Direccion',
    'Telefono',
    'Action',
  ];

  private _dialogWidth: string = '36em';
  private _duration: number = 5000;

  constructor(
    private _apiEntityService: ApiEntityService,
    private _dialog: MatDialog,
    private _snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.getEntity();
  }

  getEntity(): void {
    this._apiEntityService.get().subscribe(
      (res) => {
        if (res.result) {
          this.dataSource = new MatTableDataSource(res.data);
          this.dataSource.paginator = this._paginator;
          this.dataSource.sort = this._sort;
        }
      },
      (err) => {
        this._snackBar.open('Ocurrio un error al obtener los datos.', '', {
          duration: this._duration,
        });
        console.error(err);
      }
    );
  }

  applyFilter(event: Event): void {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue?.trim().toLowerCase() ?? '';

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  openAdd(): void {
    this.open();
  }

  openUpdate(element: IEntity): void {
    this.open(element);
  }

  private open(element: IEntity = null) {
    let dialogRef: MatDialogRef<DialogEntityComponent>;

    dialogRef = this._dialog.open(DialogEntityComponent, {
      data: element,
      width: this._dialogWidth,
    });

    dialogRef.afterClosed().subscribe((res) => {
      if (res) {
        this.getEntity();
      }
    });
  }

  openDelete(element: IEntity): void {
    const dialogRef = this._dialog.open(DialogDeleteComponent, {
      data: {
        title: 'Eliminar',
        message: `Esta seguro de querer eliminar este registro. "${element.numDocumento}"`,
      },
      width: this._dialogWidth,
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this._apiEntityService.delete(element.idEntidad).subscribe(
          (res) => {
            if (res.result) {
              this.getEntity();
              this._snackBar.open(res.message, '', {
                duration: this._duration,
              });
            }
          },
          (err) => {
            this._snackBar.open('Ocurrio un error inesperado.', '', {
              duration: this._duration,
            });
            console.error(err);
          }
        );
      }
    });
  }
}
